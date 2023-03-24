import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

readonly APIUrl="http://localhost:5000/api/v1/client";

  constructor(private http:HttpClient) { }

  getClient():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);
  }

  addClient(val:any){
    return this.http.post(this.APIUrl,val)
  }

  updateClient(val:any, id:string){
    return this.http.put(this.APIUrl+'/'+id,val)
  }

  deleteClient(id:string){
    return this.http.delete(this.APIUrl+'/'+id)
  }

}
