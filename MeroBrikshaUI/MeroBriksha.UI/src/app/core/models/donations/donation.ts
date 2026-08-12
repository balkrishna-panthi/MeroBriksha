export interface Donation {
  id: string;
  donorId: string;
  campaignId :string;
  campaignName : string;
  amount: number;
  status: string;
  paymentReference: string;
  remarks : string;
  createdDate : string;
  verifiedDate? : string;
}