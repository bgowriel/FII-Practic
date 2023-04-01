import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlatComponent } from './flat/flat.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavigationBarComponent } from './core/navigation-bar/navigation-bar.component';
import { OfficeComponent } from './office/office.component';
import { HouseComponent } from './house/house.component';
import { LandComponent } from './land/land.component';
import { SelectAddressComponent } from './core/select-address/select-address.component';
import { FlatService } from './services/flat.service';
import { OfficeService } from './services/office.service';
import { HouseService } from './services/house.service';
import { LandService } from './services/land.service';
import { AreaService } from './services/area.service';
import { AppointmentService } from './services/appointment.service';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { SearchWithOptionsComponent } from './core/search-with-options/search-with-options.component';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule, MatListOption } from '@angular/material/list';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { EstateCardComponent } from './core/estate-card/estate-card.component';
import { LoginComponent } from './login/login.component';
import { LogoComponent } from './logo/logo.component';
import { ProfileComponent } from './profile/profile.component';
import { authInterceptorProviders } from './services/auth-interceptor.service';
import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [
    AppComponent,
    FlatComponent,
    NavigationBarComponent,
    OfficeComponent,
    HouseComponent,
    LandComponent,
    LoginComponent,
    LogoComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CoreModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatExpansionModule,
    CdkAccordionModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    ScrollingModule,
    MatCheckboxModule
  ],
  providers: [
    HttpClient,
    FlatService,
    OfficeService,
    HouseService,
    LandService,
    AreaService,
    AppointmentService,
    authInterceptorProviders,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
