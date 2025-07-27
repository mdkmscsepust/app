import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent implements OnInit {
  constructor(private homeService: HomeService) {}

  ngOnInit() {
    this.homeService.getMessage().subscribe(res => {
      console.log('Message from service:', res);
    })
  }

}
