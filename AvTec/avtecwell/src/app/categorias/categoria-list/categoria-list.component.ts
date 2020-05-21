import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/shared/categoria.service';
import { Categoria } from 'src/app/shared/categoria.model';

@Component({
  selector: 'app-categoria-list',
  templateUrl: './categoria-list.component.html',
  styleUrls: ['./categoria-list.component.css']
})
export class CategoriaListComponent implements OnInit {

  constructor(private service : CategoriaService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  Edit(cat : Categoria){
    this.service.formData= Object.assign({}, cat);
  }

  Delete(cat : Categoria){
    if (confirm('Are you sure to delete this record?')) {
      this.service.delete(cat.idCategoria).subscribe(res => {
        this.service.refreshList();
      });
      
    }
  }

}
