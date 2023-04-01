import { Component, Input, OnInit, Output } from '@angular/core';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  @Output() user!: string;
  @Output() admin!: string;

  constructor(private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {
    this.user = this.tokenStorage.getUserEmail();
    if (this.tokenStorage.isAdmin) {
      this.admin = '[admin]';
    } else {
      this.admin = '';
    }
    console.log(this.admin);
  }
  
  logout(): void {
    this.tokenStorage.signOut();
    window.location.reload();
  }
}
