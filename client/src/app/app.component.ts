import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'Skinet';


  constructor(){}
  
  ngOnInit(): void {
  //  this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products?pageSize=50').subscribe({
  //   next: response=>this.products=response.data, //what to do next
  //   error: error=>console.log(error), //what to do if error
  //   complete: ()=>{
  //     console.log('request completed');
  //     console.log('extra statement');
  //   }
  //  })
  }
}
