import { Routes } from '@angular/router';
import { App } from './app';
import { Campaigns } from './components/campaigns/campaigns';
import { Dialog } from './shared/components/dialog/dialog';
import { Donors } from './components/donors/donors';
import { Donations } from './components/donations/donations';
import { Trees } from './components/trees/trees';

export const routes: Routes = [{
  path: '',
  component: Campaigns
},
  { path: 'campaigns', component: Campaigns },
  { path: 'dialog', component: Dialog } ,
  { path: 'donors', component: Donors},
  { path : 'donations', component: Donations},
  { path : 'trees', component: Trees}
];
