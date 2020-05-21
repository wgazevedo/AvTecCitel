import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/shared/produto.service';
import { Produto } from 'src/app/shared/produto.model';

@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {

  constructor(private service : ProdutoService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  Edit(p : Produto){
    this.service.formData= Object.assign({}, p);
  }

  Delete(p : Produto){
    if (confirm('Are you sure to delete this record?')) {
      this.service.delete(p.idProduto).subscribe(res => {
        this.service.refreshList();
      });
      
    }
  }

}
