import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { Header } from './shared/components/header/header';
import { Footer } from './shared/components/footer/footer';
import { CampaignTable } from './widgets/campaign-table/campaign-table'; 

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatSlideToggle, Header, Footer, CampaignTable],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('MeroBriksha.UI');
}
