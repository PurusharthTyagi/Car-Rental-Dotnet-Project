import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { LoginComponent } from './login/login.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { RentAgreementComponent } from './rent-agreement/rent-agreement.component';
import { ShowAgreementComponent } from './show-agreement/show-agreement.component';
import { AddCarComponent } from './add-car/add-car.component';
import { EditCarComponent } from './edit-car/edit-car.component';


const routes: Routes = [
  {
    path: '', 
    component: WarehouseComponent,

  },

  {
    path: 'cars/warehouse', 
    component: WarehouseComponent,

  },
  
  {
    path: 'cars/show-agreement',
    component: ShowAgreementComponent,

  },
  {
    path: 'order-details/:carId', 
   component: OrderDetailsComponent
  },
  {
    path: 'cars/add-car',
    component: AddCarComponent
  },
  {
    path: 'cars/edit-car/:carId',
    component: EditCarComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'rent-agreement',
    component: RentAgreementComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
