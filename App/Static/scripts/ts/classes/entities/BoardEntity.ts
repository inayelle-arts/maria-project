import {ColumnEntity} from "./ColumnEntity";
import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";

@JsonObject("BoardEntity")
export class BoardEntity extends EntityBase
{
	@JsonProperty("id", Number)
	private _id: number;
	
	@JsonProperty("name", String)
	private _name: string;
	
	@JsonProperty("columns", [ColumnEntity])
	private _columns: Array<ColumnEntity>;
	
	// constructor(id: number, name: string, columns: ColumnEntity[])
	// {
	// 	super();
	// 	this._id = id;
	// 	this._name = name;
	// 	this._columns = columns;
	// }
	
	get id(): number
	{
		return this._id;
	}
	
	set id(value: number)
	{
		this._id = value;
	}
	
	get name(): string
	{
		return this._name;
	}
	
	set name(value: string)
	{
		this._name = value;
	}
	
	get columns(): Array<ColumnEntity>
	{
		return this._columns;
	}
	
	set columns(value: Array<ColumnEntity>)
	{
		this._columns = value;
	}
	
	public save(): boolean
	{
		throw new Error('not implemented');
	}
}