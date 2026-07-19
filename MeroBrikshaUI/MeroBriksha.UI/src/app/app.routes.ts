import { Routes } from '@angular/router';
import { App } from './app';
import { Campaigns } from './components/campaigns/campaigns';

export const routes: Routes = [{
  path: '',
  component: Campaigns
},
  { path: 'campaigns', component: Campaigns }
];
