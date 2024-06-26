import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { QueryParametars } from '../pageing/QueryParametars.model';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private apiUrl = environment.apiUrl; // Zamijeni s URL-om tvog ASP.NET API-ja

  constructor(private http: HttpClient) { }

  getArticle(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/article/${id}`).pipe(
      map(response => response as any) // Ako je potrebno mapiranje, ovdje možeš koristiti mapirati na svoje DTO modele
    );
  }

  getArticles(params: QueryParametars): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/article/paged`, params).pipe(
      map(response => response as any) // Ako je potrebno mapiranje, ovdje možeš koristiti mapirati na svoje DTO modele
    );
  }

  createArticle(article: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/article`, article).pipe(
      map(response => response as any) // Ako je potrebno mapiranje, ovdje možeš koristiti mapirati na svoje DTO modele
    );
  }

  updateArticle(article: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/article/`, article).pipe(
      map(response => response as any) // Ako je potrebno mapiranje, ovdje možeš koristiti mapirati na svoje DTO modele
    );
  }

  deleteArticle(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/article/${id}`).pipe(
      map(response => response as any) // Ako je potrebno mapiranje, ovdje možeš koristiti mapirati na svoje DTO modele
    );
  }
}
