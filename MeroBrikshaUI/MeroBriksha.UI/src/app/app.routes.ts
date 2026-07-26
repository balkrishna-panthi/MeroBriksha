import { Routes } from '@angular/router';
import { App } from './app';
import { Campaigns } from './components/campaigns/campaigns';
import { Dialog } from './shared/components/dialog/dialog';

export const routes: Routes = [{
  path: '',
  component: Campaigns
},
  { path: 'campaigns', component: Campaigns },
  { path: 'dialog', component: Dialog } 
];
