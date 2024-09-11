import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { HeaderComponent } from "./layout/header/header.component";
import { Pagination } from './shared/models/pagination';
import { Product } from './shared/models/product';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title: string = 'Skinet-2024';
  baseURL: string = "https://localhost:5001/api/";
  products: Product[] = [];
  
  private http = inject(HttpClient);

  ngOnInit(): void {
    this.http
          .get<Pagination<Product>>(this.baseURL + 'products')
          .subscribe({
            next: response => this.products = response.data,
            error: error => console.log(error),
            complete: () => console.log('complete')
          })
  }
}
