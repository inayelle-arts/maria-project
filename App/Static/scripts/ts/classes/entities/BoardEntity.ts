import {ColumnEntity} from "./ColumnEntity";
import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";
import {ProjectEntity} from "./ProjectEntity";

@JsonObject("BoardEntity")
export class BoardEntity extends EntityBase
{
	@JsonProperty("id", Number)
	private _id: number;
	
	@JsonProperty("name", String)
	private _name: string;
	
	@JsonProperty("columns", [ColumnEntity])
	private _columns: Array<ColumnEntity>;
	
	@JsonProperty("project", ProjectEntity)
	private _project: ProjectEntity;
	
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
	
	get project(): ProjectEntity
	{
		return this._project;
	}
	
	set project(value: ProjectEntity)
	{
		this._project = value;
	}
	
	public save(): boolean
	{
		throw new Error('not implemented');
	}
}