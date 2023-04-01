import { Injector, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './core/about/about.component';
import { FlatComponent } from './flat/flat.component';
import { HouseComponent } from './house/house.component';
import { LandComponent } from './land/land.component';
import { LoginComponent } from './login/login.component';
import { OfficeComponent } from './office/office.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AuthenticationService } from './services/authentication.service';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent},
  { path: 'flats', canActivate: [AuthGuardService], component: FlatComponent },
  { path: 'offices', canActivate: [AuthGuardService], component: OfficeComponent },
  { path: 'houses', canActivate: [AuthGuardService], component: HouseComponent },
  { path: 'lands', canActivate: [AuthGuardService], component: LandComponent },
  { path: 'about', canActivate: [AuthGuardService], component: AboutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
