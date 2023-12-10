export interface Hero {
    name:string;
    power:string;
    stats: { key: string, value: number }[];
    evolve(statIncrease?: number): void;
}

