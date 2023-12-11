export interface IHero {
    name: string;
    power: string;
    stats: KeyValuePair<string, number>[];
    evolve(): void;
  }
  
  export class Hero implements IHero {
    name: string;
    power: string;
    stats: KeyValuePair<string, number>[] = [];
  
    constructor(name: string, power: string, stats: KeyValuePair<string, number>[] = []) {
      this.name = name;
      this.power = power;
      this.stats = stats;
    }
  
    evolve(): void {
      this.stats.forEach(stat => {
        stat.value += 0.5 * stat.value;
      });
    }
  }
  
  export interface KeyValuePair<K, V> {
    key: K;
    value: V;
  }
  