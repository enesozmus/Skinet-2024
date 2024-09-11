import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';

@Injectable({
    providedIn: 'root'
})
export class ShopService {

    private http = inject(HttpClient);

    baseURL: string = "https://localhost:5001/api/";
    types: string[] = [];
    brands: string[] = [];

    getProducts() {
        return this.http
            .get<Pagination<Product>>(this.baseURL + 'products');
    }
}