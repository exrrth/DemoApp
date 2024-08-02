import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  
  private accountService = inject(AccountService);
  title = 'DatingApp';
  

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userSting = localStorage.getItem('user');
    if(!userSting) return;

    const user = JSON.parse(userSting);
    this.accountService.currentUser.set(user);
  }

  

}
