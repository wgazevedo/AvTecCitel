import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/shared/categoria.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  constructor(public service : CategoriaService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    // if(form != null)
      // form.resetForm();
    this.service.formData = {
      idCategoria : 0,
      descricao : '',
      sigla : '',
      ativo : true,
    }
  }

  onSubmit(form: NgForm){
    if(form.value.idCategoria == 0)
      this.insert(form);
    else
      this.update(form);

    this.service.refreshList();
  }

  update(form: NgForm){
    this.service.put(form.value).subscribe(res => {
      this.resetForm(form);
    });
  }

  insert(form: NgForm){
    this.service.post(form.value).subscribe(res => {
      this.resetForm(form);
    });
  }

}
