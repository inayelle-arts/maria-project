import {Column} from "./Column";

export class Board
{
	private readonly _id: number;
	private _name: string;
	
	private readonly _columns: Column[];
	
	constructor(id: number, name: string, columns: Column[])
	{
		this._id = id;
		this._name = name;
		this._columns = columns;
	}
	
	get columns(): Column[]
	{
		return this._columns;
	}
	
	get name(): string
	{
		return this._name;
	}
	
	set name(value: string)
	{
		this._name = value;
	}
}