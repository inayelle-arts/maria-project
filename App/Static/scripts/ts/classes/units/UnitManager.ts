import {BoardUnit} from "./BoardUnit";

export class UnitManager
{
	private static readonly __instance__ = new UnitManager();
	
	private _boardUnit: BoardUnit;
	
	public static getInstance(): UnitManager
	{
		return this.__instance__;
	}
	
	public set BoardUnit(u: BoardUnit)
	{
		this._boardUnit = u;
	}
	
	public get BoardUnit(): BoardUnit
	{
		return this._boardUnit;
	}
}