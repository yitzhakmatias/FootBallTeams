import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    selector: 'team',
    templateUrl: './team.component.html'
})
export class TeamDataComponent {
    public teams: Team[];
    public tournaments: Tournament[];
    public cacheForecasts: Team[];
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Team/GetTeams').subscribe(result => {
            this.teams = result.json() as Team[];
            this.cacheForecasts = this.teams;
        }, error => console.error(error));

        http.get(baseUrl + 'api/Tournament/GetTournaments').subscribe(result => {
            this.tournaments = result.json() as Tournament[];
        }, error => console.error(error));
    }
    filterTeams(filterVal: any) {

        if (filterVal == "0")
            this.teams = this.cacheForecasts;
        else
            this.teams = this.cacheForecasts.filter((item) => item.tournamentId == filterVal);
    }
}

interface Team {
    name: string;
    score: number;
    tournamentId: number;
}
interface Tournament {
    tournamentId: number;
    name: string;
}