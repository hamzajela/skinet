import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrl: './test-errors.component.scss'
})
export class TestErrorsComponent {
 baseUrl=environment.apiUrl;
 validationErros:string[]=[];


 constructor (private http:HttpClient){}

  get404Error (){
   this.http.get(this.baseUrl+'products/42').subscribe({
    next:response=>console.log(response),
    error: error=>console.log(error)
    
    
   })
  }

  get500Error (){
    this.http.get(this.baseUrl+'buggy/servererror').subscribe({
     next:response=>console.log(response),
     error: error=>console.log(error)
     
     
    })
   }

   get400Error (){
    this.http.get(this.baseUrl+'buggy/badrequest').subscribe({
     next:response=>console.log(response),
     error: error=>console.log(error)
     
     
    })
   }

   get400ValidationError (){
    this.http.get(this.baseUrl+'products/fortytwo').subscribe({
     next:response=>console.log(response),
     error: error=>{
      console.log(error);
      this.validationErros=error.errors;
    }
     
    })
   }




}
