import { CrudBase } from "./CrudBase";

export class Heating extends CrudBase {
    public projectId: number = 0;
    public systemName: string = "";
    public systemAmount: number = 0;
    public roomName: string = "";
    public installTypeName: string = "";
    public fanTypeName: string = "";
    public fanAirConsumption: number = 0;
    public fanHead: number = 0;
    public fanSpeed: number = 0;
    public fanMotorTypeName: string = "";    
    public fanMotorPower: number = 0;
    public fanMotorSpeed: number = 0; 
    public airHeaterTypeName: string = ""; 
    public airHeaterAmount: number = 0;
    public airHeaterHeatingTempFrom: number = 0;
    public airHeaterHeatingTempTo: number = 0;  
    public airHeaterPowerConsumption: number = 0;
    public airHeaterResistanceAir: number = 0;
    public airHeaterResistanceWater: number = 0;  
    public recuperatorTypeName: string = ""; 
    public recuperatorAmount: number = 0; 
    public recuperatorAirConsumptionHeating: number = 0;  
    public recuperatorAirConsumptionHeated: number = 0; 
    public recuperatorHeatingTempFrom: number = 0;
    public recuperatorHeatingTempTo: number = 0;  
    public recuperatorPowerConsumption: number = 0;  
    public recuperatorEfficiency: number = 0;  
    public recuperatorResistanceHeating: number = 0;  
    public recuperatorResistanceHeated: number = 0;
    public filterTypeName: string = "";
    public filterAmount: number = 0;
    public filterResistance: number = 0;
    public airCoolerTypeName: string = "";
    public airCoolerAmount: number = 0;
    public airCoolerCoolingTempFrom: number = 0;
    public airCoolerCoolingTempTo: number = 0;
    public airCoolerColdConsumption: number = 0;
    public airCoolerResistance: number = 0;
    public comment: string = ""; 
}