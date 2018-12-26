import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";

@JsonObject("ProjectEntity")
export class ProjectEntity extends EntityBase
{
	@JsonProperty("id", Number)
	private _id: number;
	
	@JsonProperty("name", String)
	private _name: string;
	
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
	
	save(): boolean
	{
		throw new Error('not implemented save()');
	}
}