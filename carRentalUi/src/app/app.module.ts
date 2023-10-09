import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PageHeaderComponent } from './page-header/page-header.component';
import { PageFooterComponent } from './page-footer/page-footer.component';
import { MaterialModule } from './material/material.module';
import { SidenavComponent } from './sidenav/sidenav.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { RentAgreementComponent } from './rent-agreement/rent-agreement.component';
import { ShowAgreementComponent } from './show-agreement/show-agreement.component';
import { AddCarComponent } from './add-car/add-car.component';
import { EditCarComponent } from './edit-car/edit-car.component';
import { HttpClientModule } from '@angular/common/http';
import { MakerPipe } from './Pipes/maker.pipe';
import { ModelPipe } from './Pipes/model.pipe';
import { RentalPricePipe } from './Pipes/rental-price.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PageHeaderComponent,
    PageFooterComponent,
    SidenavComponent,
    WarehouseComponent,
    LoginComponent,
    OrderDetailsComponent,
    RentAgreementComponent,
    ShowAgreementComponent,
    AddCarComponent,
    EditCarComponent,
    MakerPipe,
    ModelPipe,
    RentalPricePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],

  bootstrap: [AppComponent],
})
export class AppModule {}
