import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";

@JsonObject("TaskEntity")
export class TaskEntity extends EntityBase
{
	@JsonProperty("id", Number)
	private _id: number;
	
	@JsonProperty("name", String)
	private _name: string;
	
	@JsonProperty("description", String)
	private _description: string;
	
	@JsonProperty("code", String)
	private _code: string;
	
	// constructor(id: number, name: string, description: string, code: string)
	// {
	// 	super();
	// 	this._id = id;
	// 	this._name = name;
	// 	this._description = description;
	// 	this._code = code;
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
	
	get description(): string
	{
		return this._description;
	}
	
	set description(value: string)
	{
		this._description = value;
	}
	
	get code(): string
	{
		return this._code;
	}
	
	set code(value: string)
	{
		this._code = value;
	}
	
	public save(): boolean
	{
		throw new Error('not implemented');
	}
}
