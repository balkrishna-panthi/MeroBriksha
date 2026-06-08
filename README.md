# MeroBriksha Workflow & Modular Architecture

> **Project:** MeroBriksha  
> **Purpose:** Donation-to-tree lifecycle tracking system for a tree plantation campaign in Tamghas/Gulmi, Nepal  
> **Technical Stack:** ASP.NET Core Web API, EF Core Code First, SQL Server  
> **Architecture Direction:** Workflow-first, modular, pluggable, and suitable for future municipality/youth club handover

---

## 1. Vision

MeroBriksha is not intended to be a simple CRUD application.  
The goal is to build a public accountability and lifecycle tracking system where a donation can become a real, traceable planted tree.

The system should support the full journey:

```text
Donation → Verification → Tree Assignment → Plantation → Public Tracking → Monitoring
```

The long-term idea is that the system could be handed over to a municipality, youth club, or local campaign organizer. Therefore, the design should remain modular, extensible, and ready for future integrations such as:

- Municipality systems
- National address databases
- Payment gateways
- Map providers
- QR code generation
- Public reporting
- SMS/email notifications
- Photo/file storage

---

## 2. Core Design Principle

The main design principle for MeroBriksha is:

> **Use case first, workflow second, entity third, database fourth, endpoint last.**

Instead of asking:

```text
Which table should I create next?
```

The better question is:

```text
Which real-world step should the system support next?
```

This helps prevent the project from becoming just:

```text
Donor CRUD + Plant CRUD + Donation CRUD + Authentication
```

The system should instead be shaped around real-world accountability and traceability.

---

## 3. Naming and Code Style Convention

The current convention for the project is:

| Layer / Purpose | Naming Style |
|---|---|
| Entity/database-facing attributes | `UPPERCASE` |
| EF Core configuration / database column mapping | `UPPERCASE` |
| DTOs / API request-response models | `PascalCase` |
| Services, controllers, C# class names | `PascalCase` |

Example entity:

```csharp
public class Donor
{
    public string ID { get; set; }
    public string FULLNAME { get; set; }
    public string? EMAIL { get; set; }
    public DateTime CREATEDDATE { get; set; }
}
```

Example DTO:

```csharp
public class CreateDonorRequest
{
    public string FullName { get; set; }
    public string? Email { get; set; }
}
```

This keeps the database/entity layer consistent while keeping the public API clean and readable.

---

## 4. High-Level Workflow

The main MeroBriksha workflow should be:

```text
Campaign Created
      ↓
Donor Registered
      ↓
Donation Registered
      ↓
Donation Verified
      ↓
Tree Assignment Created
      ↓
Plant Species Selected
      ↓
Planting Location Assigned
      ↓
Tree Marked as Planted
      ↓
Donor Recognition Generated
      ↓
Tree Published Publicly
      ↓
Tree Monitoring Updates Continue
```

In plain English:

1. A campaign is created by a municipality, youth club, or organizer.
2. A donor contributes money to the campaign.
3. The donation is registered in the system.
4. The donation is verified.
5. A tree assignment is created from the verified donation.
6. A plant species is selected.
7. A planting location is assigned.
8. The tree is planted and given a tracking code.
9. Donor recognition may be generated.
10. The tree becomes publicly trackable.
11. The tree status is updated over time.

---

## 5. Core Modules

MeroBriksha can be divided into the following business modules.

---

### 5.1 Campaign Management

A campaign represents a plantation activity.

Example:

```text
Tamghas Green Campaign 2081
```

A campaign answers:

- Who is organizing this?
- Where is it happening?
- What is the goal?
- How many trees are targeted?
- When does it start and end?
- How many donations have been received?
- How many trees have been planted?

Possible entity:

```csharp
public class Campaign
{
    public string ID { get; set; }

    public string NAME { get; set; }
    public string? DESCRIPTION { get; set; }

    public string ORGANIZERNAME { get; set; }

    public DateTime STARTDATEUTC { get; set; }
    public DateTime? ENDDATEUTC { get; set; }

    public int? TARGETTREECOUNT { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

DTO example:

```csharp
public class CreateCampaignRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string OrganizerName { get; set; }
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public int? TargetTreeCount { get; set; }
}
```

---

### 5.2 Donor Management

A donor is a person, group, organization, or institution contributing money to the campaign.

Examples:

```text
Balkrishna Panthi
ABC Youth Group
Resunga Municipality Staff Group
```

Possible entity:

```csharp
public class Donor
{
    public string ID { get; set; }

    public string FULLNAME { get; set; }
    public string? EMAIL { get; set; }
    public string? PHONENUMBER { get; set; }

    public bool ISPUBLIC { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

DTO example:

```csharp
public class CreateDonorRequest
{
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsPublic { get; set; }
}
```

Important design note:

```text
Donor should not directly own a Tree.
```

Preferred flow:

```text
Donor → Donation → TreeAssignment → Tree
```

This keeps the design flexible because:

- One donor can donate multiple times.
- One donation may support one or more trees.
- A tree may be assigned only after donation verification.
- A donor may want public or private recognition.

---

### 5.3 Donation Management

A donation represents a financial contribution to a campaign.

Donation should connect:

```text
Donor
Campaign
Amount
Payment/verification status
```

Possible status:

```csharp
public enum DonationStatus
{
    Registered,
    PendingVerification,
    Verified,
    Rejected,
    Refunded
}
```

Possible entity:

```csharp
public class Donation
{
    public string ID { get; set; }

    public string DONORID { get; set; }
    public Donor Donor { get; set; }

    public string CAMPAIGNID { get; set; }
    public Campaign Campaign { get; set; }

    public decimal AMOUNT { get; set; }

    public DonationStatus STATUS { get; set; }

    public string? PAYMENTREFERENCE { get; set; }
    public string? REMARKS { get; set; }

    public DateTime CREATEDDATE { get; set; }
    public DateTime? VERIFIEDDATE { get; set; }
}
```

Create DTO:

```csharp
public class CreateDonationRequest
{
    public string DonorId { get; set; }
    public string CampaignId { get; set; }
    public decimal Amount { get; set; }
    public string? PaymentReference { get; set; }
    public string? Remarks { get; set; }
}
```

Verification DTO:

```csharp
public class VerifyDonationRequest
{
    public string? VerificationRemarks { get; set; }
}
```

Business-focused endpoints:

```text
POST /api/donations
POST /api/donations/{id}/verify
POST /api/donations/{id}/reject
```

These are better than only using a generic update endpoint such as:

```text
PUT /api/donations/{id}
```

because they express actual business actions.

---

### 5.4 Plant Species Catalog

The current `Plant` module should conceptually be treated as a plant species catalog.

Recommended naming:

```text
PlantSpecies
```

Reason:

```text
PlantSpecies = type/catalog of plant
Tree = actual planted tree instance
```

Example:

```text
PlantSpecies: Peepal
Tree: Peepal tree planted near Tamghas Bus Park with tracking code MBT-000001
```

Possible entity:

```csharp
public class PlantSpecies
{
    public string ID { get; set; }

    public string NAME { get; set; }
    public string? SCIENTIFICNAME { get; set; }
    public string? DESCRIPTION { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

DTO example:

```csharp
public class PlantSpeciesResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? ScientificName { get; set; }
    public string? Description { get; set; }
}
```

This distinction should be made early to avoid confusion later.

---

### 5.5 Tree Assignment

Tree Assignment is one of the most important modules.

A `TreeAssignment` is the bridge between a verified donation and a future planted tree.

It exists because after donation verification, the actual tree may not be planted immediately. The system may still need to decide:

- Which plant species?
- How many trees?
- Which location?
- Which donor recognition name?
- Which campaign?
- Who will plant it?

Possible status:

```csharp
public enum TreeAssignmentStatus
{
    Pending,
    PlantSpeciesSelected,
    LocationAssigned,
    Planted,
    Published,
    Cancelled
}
```

Possible entity:

```csharp
public class TreeAssignment
{
    public string ID { get; set; }

    public string DONATIONID { get; set; }
    public Donation Donation { get; set; }

    public string? PLANTSPECIESID { get; set; }
    public PlantSpecies? PlantSpecies { get; set; }

    public TreeAssignmentStatus STATUS { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

Possible endpoint:

```text
POST /api/donations/{donationId}/tree-assignments
```

Meaning:

```text
Create a tree assignment from this verified donation.
```

This is better than directly creating a tree manually.

---

### 5.6 Location & Mapping

Location should be designed carefully because it may later connect with municipality systems or national address databases.

For MVP, address values can be manually entered.

For future extensibility, location should allow external address references.

Possible entity:

```csharp
public class Location
{
    public string ID { get; set; }

    public string? PROVINCENAME { get; set; }
    public string? DISTRICTNAME { get; set; }
    public string? MUNICIPALITYNAME { get; set; }
    public int? WARDNUMBER { get; set; }

    public string? AREANAME { get; set; }

    public decimal? LATITUDE { get; set; }
    public decimal? LONGITUDE { get; set; }

    public string? EXTERNALADDRESSPROVIDER { get; set; }
    public string? EXTERNALADDRESSCODE { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

DTO example:

```csharp
public class CreateLocationRequest
{
    public string? ProvinceName { get; set; }
    public string? DistrictName { get; set; }
    public string? MunicipalityName { get; set; }
    public int? WardNumber { get; set; }

    public string? AreaName { get; set; }

    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public string? ExternalAddressProvider { get; set; }
    public string? ExternalAddressCode { get; set; }
}
```

Future example:

```text
ExternalAddressProvider = NepalNationalAddressDB
ExternalAddressCode = NP-GULMI-RESUNGA-WARD-04
```

For MVP, these fields can remain null.

---

### 5.7 Tree

A `Tree` is the actual planted tree instance.

This should be created when the tree is actually planted or ready to be tracked.

Possible status:

```csharp
public enum TreeStatus
{
    Planted,
    Healthy,
    NeedsAttention,
    Damaged,
    Dead,
    Replaced
}
```

Possible entity:

```csharp
public class Tree
{
    public string ID { get; set; }

    public string TRACKINGCODE { get; set; }

    public string TREEASSIGNMENTID { get; set; }
    public TreeAssignment TreeAssignment { get; set; }

    public string LOCATIONID { get; set; }
    public Location Location { get; set; }

    public DateTime PLANTEDDATEUTC { get; set; }

    public TreeStatus STATUS { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

Workflow endpoint:

```text
POST /api/tree-assignments/{id}/mark-planted
```

DTO example:

```csharp
public class MarkTreePlantedRequest
{
    public string LocationId { get; set; }
    public DateTime PlantedDateUtc { get; set; }
}
```

When this endpoint is called, the system should:

1. Check that the tree assignment exists.
2. Check that it is not already planted.
3. Check that required information exists.
4. Create the actual `Tree`.
5. Generate a tracking code.
6. Set the tree status to `Planted`.
7. Update the tree assignment status to `Planted`.

---

### 5.8 Donor Recognition

Donor recognition is for:

- Name plates
- Public donor display
- Certificates
- QR labels
- Memorial or dedication messages

Possible entity:

```csharp
public class Recognition
{
    public string ID { get; set; }

    public string TREEASSIGNMENTID { get; set; }
    public TreeAssignment TreeAssignment { get; set; }

    public string DISPLAYNAME { get; set; }

    public bool ISPUBLIC { get; set; }

    public string? MESSAGE { get; set; }

    public DateTime CREATEDDATE { get; set; }
}
```

This should be separate from `Donor` because the donor may want a different public display name.

Example:

```text
Real donor name: Balkrishna Panthi
Recognition name: In memory of my grandfather
```

---

### 5.9 Tree Monitoring

Tree monitoring makes the system useful after the planting event.

A municipality or youth club can update the tree status over time.

Possible entity:

```csharp
public class TreeMonitoringUpdate
{
    public string ID { get; set; }

    public string TREEID { get; set; }
    public Tree Tree { get; set; }

    public TreeStatus STATUS { get; set; }

    public string? REMARKS { get; set; }
    public string? PHOTOURL { get; set; }

    public DateTime CHECKEDDATEUTC { get; set; }
    public DateTime CREATEDDATE { get; set; }
}
```

Endpoint:

```text
POST /api/trees/{treeId}/monitoring-updates
```

DTO example:

```csharp
public class CreateTreeMonitoringUpdateRequest
{
    public TreeStatus Status { get; set; }
    public string? Remarks { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CheckedDateUtc { get; set; }
}
```

This module turns MeroBriksha into a long-term accountability system.

---

### 5.10 Public Transparency

Public endpoints should be separate from admin/internal workflow endpoints.

Possible public endpoints:

```text
GET /api/public/campaigns/{campaignId}
GET /api/public/campaigns/{campaignId}/trees
GET /api/public/trees/{trackingCode}
GET /api/public/campaigns/{campaignId}/summary
```

Example public response DTO:

```csharp
public class PublicTreeTrackingResponse
{
    public string TrackingCode { get; set; }

    public string CampaignName { get; set; }

    public string? DonorDisplayName { get; set; }

    public string PlantName { get; set; }
    public string? ScientificName { get; set; }

    public string? MunicipalityName { get; set; }
    public int? WardNumber { get; set; }
    public string? AreaName { get; set; }

    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public string Status { get; set; }

    public DateTime PlantedDateUtc { get; set; }
}
```

Public users should not see private/internal information such as:

- Private donor phone number
- Private donor email
- Internal verification remarks
- Payment reference details
- Admin notes

Therefore, public DTOs should be separate from admin DTOs.

---

## 6. External Integration Design

Do not implement integrations immediately, but design the system so that integrations can be added later.

Possible future integrations:

| Integration | Purpose |
|---|---|
| Payment Gateway | Verify donations automatically |
| QR Code Generator | Generate QR codes for trees/name plates |
| Map Provider | Generate map links and tree map views |
| SMS/Email Service | Notify donors and admins |
| National Address Database | Use official address/ward codes |
| Municipality System | Sync campaign and plantation data |
| Photo/File Storage | Store tree photos and monitoring evidence |
| PDF Certificate Generator | Generate donor certificates |
| Public Report Exporter | Export campaign progress reports |

Use interfaces for future plug-ins.

Example:

```csharp
public interface IQrCodeService
{
    Task<string> GenerateTreeQrCodeAsync(string trackingCode);
}
```

```csharp
public interface IMapProvider
{
    Task<string> GenerateMapLinkAsync(decimal latitude, decimal longitude);
}
```

```csharp
public interface IPaymentVerificationService
{
    Task<bool> VerifyPaymentAsync(string paymentReference);
}
```

For now, these can have simple or fake implementations later.

The important rule is:

```text
Do not hardcode future external services directly into controllers.
```

---

## 7. Entity Relationship Overview

Main relationship:

```text
Campaign 1 ─── * Donation
Donor    1 ─── * Donation

Donation 1 ─── * TreeAssignment

TreeAssignment * ─── 0..1 PlantSpecies
TreeAssignment 1 ─── 0..1 Tree
TreeAssignment 1 ─── 0..1 Recognition

Tree * ─── 1 Location
Tree 1 ─── * TreeMonitoringUpdate
```

Plain English:

- A campaign has many donations.
- A donor can make many donations.
- A donation can create one or more tree assignments.
- A tree assignment selects one plant species.
- A tree assignment eventually becomes one actual tree.
- A tree has one location.
- A tree has many monitoring updates.
- A tree assignment may have one recognition record.

---

## 8. Suggested API Workflow

### Step 1: Create Campaign

```http
POST /api/campaigns
```

---

### Step 2: Create Donor

```http
POST /api/donors
```

---

### Step 3: Register Donation

```http
POST /api/donations
```

Request includes:

```text
DonorId
CampaignId
Amount
PaymentReference
Remarks
```

Initial donation status:

```text
Registered / PendingVerification
```

---

### Step 4: Verify Donation

```http
POST /api/donations/{id}/verify
```

Donation status becomes:

```text
Verified
```

---

### Step 5: Create Tree Assignment from Donation

```http
POST /api/donations/{donationId}/tree-assignments
```

Tree assignment status becomes:

```text
Pending
```

---

### Step 6: Select Plant Species

```http
POST /api/tree-assignments/{id}/select-plant-species
```

Alternative:

```http
PUT /api/tree-assignments/{id}/plant-species
```

Tree assignment status becomes:

```text
PlantSpeciesSelected
```

---

### Step 7: Create or Assign Location

Create location:

```http
POST /api/locations
```

Assign location:

```http
POST /api/tree-assignments/{id}/assign-location
```

---

### Step 8: Mark Tree as Planted

```http
POST /api/tree-assignments/{id}/mark-planted
```

System creates actual tree with tracking code:

```text
MBT-000001
```

---

### Step 9: Public Tracking

```http
GET /api/public/trees/MBT-000001
```

---

### Step 10: Add Monitoring Update

```http
POST /api/trees/{treeId}/monitoring-updates
```

---

## 9. MVP Scope

The MVP should prove the main lifecycle:

> **A donor's verified donation can become a publicly trackable planted tree.**

### Include in MVP Phase 1

- Campaign
- Donor
- Donation
- PlantSpecies
- TreeAssignment
- Location
- Tree
- TreeMonitoringUpdate
- Public tree tracking

### Exclude from MVP Phase 1

- Payment gateway
- Authentication/authorization
- QR code generation
- SMS/email notification
- Real map provider integration
- PDF certificate generation
- Advanced reporting
- Municipality hierarchy
- Photo upload

These should be designed for, but not implemented immediately.

---

## 10. Recommended Implementation Order

The recommended implementation order is:

```text
1. Rename/rethink Plant as PlantSpecies.
2. Add Campaign entity.
3. Add Donation entity or update Donation if already started.
4. Add DonationStatus.
5. Add donation verification workflow.
6. Add TreeAssignment entity.
7. Add endpoint to create TreeAssignment from verified Donation.
8. Add Location entity.
9. Add Tree entity.
10. Add endpoint to mark TreeAssignment as planted.
11. Add public tree tracking endpoint.
12. Add TreeMonitoringUpdate.
```

Do not implement all APIs blindly.

Implement one business flow at a time.

---

## 11. Next Coding Milestone

Since the `Donor` module and current `Plant` module are already working, the next milestone should be:

```text
Donor exists
Campaign exists
Donation is registered
Donation is verified
```

After this milestone, move to:

```text
Verified donation creates TreeAssignment
```

This is the correct foundation for the system.

---

## 12. Final Architecture Direction

MeroBriksha should be designed around this lifecycle:

```text
A donor contributes to a campaign.
The donation is verified.
The verified donation is assigned to a tree.
The tree is planted at a known location.
The tree receives a tracking code.
The public can track the tree.
The tree can be monitored over time.
```

This makes MeroBriksha more than a CRUD application.

It becomes a donation-to-tree accountability platform suitable for future municipality or youth club handover.

