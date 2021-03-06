﻿import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'isomorphic-fetch';
import config from './authConfig';
@inject(HttpClient)
export class Identity{
    heading = 'Identity as known in the web api';
    identityInApi="waiting for identity information";
    constructor(http){
        http.configure(config => {
            config
              .useStandardConfiguration();
        });

        this.http = http;
    }

    activate(){
        let url = config.apiServerBaseAddress + ':57391/api/Identity';

        return this.http.fetch(url)
		.then(response => {
		    return response.json();
		})
		.then(c => {
		    return this.identityInApi = c;
		});
    }

}
