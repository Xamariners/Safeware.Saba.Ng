import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MasterEntityComponent } from './components/master-entity.component';

export const routes: Routes = [
  {
    path: '',
    component: MasterEntityComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MasterEntityRoutingModule {}
