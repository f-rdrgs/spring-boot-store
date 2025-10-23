import { Injectable, OnInit } from '@angular/core';
import DataInfo from "../../assets/config.json";
@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  constructor() { }


  /**
   * getAPIURL
   */
  public getAPIURL() : string {
    return DataInfo.apiBaseUrl;   
  }
}
