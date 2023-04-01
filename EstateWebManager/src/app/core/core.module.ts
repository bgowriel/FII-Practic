import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchWithOptionsComponent } from './search-with-options/search-with-options.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { SelectAddressComponent } from './select-address/select-address.component';
import { AboutComponent } from './about/about.component';
import { SelectPriceComponent } from './select-price/select-price.component';
import { EstateCardComponent } from './estate-card/estate-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { PaginatorComponent } from './paginator/paginator.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { EstateDetailsComponent } from './estate-details/estate-details.component';
import { FormsModule } from '@angular/forms';
import { MatListModule, MatListOption } from '@angular/material/list';
import { PostOfferComponent } from './post-offer/post-offer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ManageOffersComponent } from './manage-offers/manage-offers.component';


@NgModule({
  declarations: [
    SearchWithOptionsComponent,
    SelectAddressComponent,
    AboutComponent,
    SelectPriceComponent,
    EstateCardComponent,
    PaginatorComponent,
    EstateDetailsComponent,
    PostOfferComponent,
    ManageOffersComponent,
    AboutComponent,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatCardModule,
    MatIconModule,
    MatPaginatorModule,
    FormsModule,
    MatListModule,
    ReactiveFormsModule,
  ],
  exports: [
    SearchWithOptionsComponent,
    SelectAddressComponent,
    SelectPriceComponent,
    EstateCardComponent,
    PaginatorComponent,
    EstateDetailsComponent,
    PostOfferComponent,
    AboutComponent,
  ],
})
export class CoreModule {}
