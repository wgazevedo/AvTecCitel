import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/shared/produto.service';
import { NgForm } from '@angular/forms';
import { CategoriaService } from 'src/app/shared/categoria.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  constructor(public service : ProdutoService, public servicecat : CategoriaService) { }

  ngOnInit() {
    this.resetForm();
    this.servicecat.refreshList();
  }

  resetForm(form? : NgForm){
    // if(form != null)
      // form.resetForm();
    this.service.formData = {
      idProduto: 0,
      idCategoria : 0,
      descricao : '',
      sigla : '',
      ativo : true,
      categoria: null,
      sku: '',
      marca: '',
      modelo: '',
    }
  }

  onSubmit(form: NgForm){
    if(form.value.idProduto == 0)
      this.insert(form);
    else
      this.update(form);
  }

  update(form: NgForm){
    this.service.put(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  insert(form: NgForm){
    this.service.post(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

}
