import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'; 
import { Hero } from '../../types/interfaces'; 

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  contacts: Hero[] = [];
  heroColor: string = ''; 

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts(): void {
    this.apiService.getContacts().subscribe(
      (data: any) => {
        this.contacts = data;
        console.log('Contacts:', this.contacts);
      },
      error => {
        console.error('Error fetching contacts:', error);
      }
    );
  
  }

  evolveHero(hero: Hero): void {
    const evolveEndpoint = 'http://localhost:4201/evolve';

    const evolvePayload = {
      name: hero.name,
      action: 'evolve'
    };

    this.apiService.post(evolveEndpoint, evolvePayload).subscribe(
      response => {
        console.log('Hero evolved successfully:', response);
      },
      error => {
        console.error('Error evolving hero:', error);
      }
    );
 }

 getStatValue(stats: { key: string, value: number }[], statName: string): number {
  const stat = stats.find(s => s.key === statName);
  return stat ? stat.value : 0;
}
setRandomHeroColor(): void {
  const colorOptions = ['color1', 'color2', 'color3', 'color4'];
  this.heroColor = colorOptions[Math.floor(Math.random() * colorOptions.length)];
}
}
