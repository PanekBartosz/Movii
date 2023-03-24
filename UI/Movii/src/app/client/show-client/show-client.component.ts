import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  constructor(private service:SharedService) { }

  
  @Input() clientId:string;

  ClientList:any=[];

  ModalTitle:string;
  ActivateAddEditClientComp:boolean=false;
  client:any;

  ngOnInit(): void {
    this.refreshgetClient();
  }
  
  addClick(){
    this.client={
      ClientId:"",
      ClientName:"",
      ClientLastName:"",
      BirthDate:"",
      Gender:"",
      ClientHistory:"",
      ClientAddress:""
    }
    this.ModalTitle="Add Client";
    this.ActivateAddEditClientComp=true;
  }

  editClick(item:any){
    this.client=item;
    this.ModalTitle="Edit Client";
    this.ActivateAddEditClientComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure ?')){
      this.service.deleteClient(item.clientId).subscribe(data=>{
        alert('Client Deleted !');
        this.refreshgetClient();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditClientComp=false;
    this.refreshgetClient();
  }

  refreshgetClient(){
    this.service.getClient().subscribe(data=>{
      this.ClientList=data;
    });
  }

}
