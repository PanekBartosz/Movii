import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-client',
  templateUrl: './add-edit-client.component.html',
  styleUrls: ['./add-edit-client.component.css']
})
export class AddEditClientComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() client:any;
  clientId:string;
  clientName:string;
  clientLastName:string;
  birthDate:string;
  gender:string;
  clientHistory:string;
  clientAddress:string;

  ngOnInit(): void {
    this.clientId=this.client.clientId;
    this.clientName=this.client.clientName;
    this.clientLastName=this.client.clientLastName;
    this.birthDate=this.client.birthDate;
    this.gender=this.client.gender;
    this.clientHistory=this.client.clientHistory;
    this.clientAddress=this.client.clientAddress;
  }

  addClient(){
    var val = {clientId:this.clientId,
      clientName:this.clientName,
      clientLastName:this.clientLastName,
      birthDate:this.birthDate,
      gender:this.gender,
      clientHistory:this.clientHistory,
      clientAddress:this.clientAddress
    };
      this.service.addClient(val).subscribe(res=>{
        alert('Added Client !');
      });
    }
  
    updateClient(){
      var val = {clientId:this.clientId,
        clientName:this.clientName,
        clientLastName:this.clientLastName,
        birthDate:this.birthDate,
        gender:this.gender,
        clientHistory:this.clientHistory,
        clientAddress:this.clientAddress};
      this.service.updateClient(val,this.clientId).subscribe(res=>{
        alert('Updated Client Data !');
      });
    }

}
