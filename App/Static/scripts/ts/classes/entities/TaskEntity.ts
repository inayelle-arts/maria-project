import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";
import {RepositoryManager} from "../repos/RepositoryManager";
import {ResponseResultSet} from "../repos/ResponseResultSet";
import {SequentialContraintEntity} from "./SequentialContraintEntity";

@JsonObject("TaskEntity")
export class TaskEntity extends EntityBase
{
	@JsonProperty("id", Number)
	public id: number;
	
	@JsonProperty("name", String)
	public name: string;
	
	@JsonProperty("description", String)
	public description: string;
	
	@JsonProperty("code", String)
	public code: string;
	
	@JsonProperty("columnId", String)
	public columnId: number;
	
	public creatorId: number = 1;
	
	public constraints: Array<SequentialContraintEntity>;
	
	constructor()
	{
		super();
		this.constraints = new Array<SequentialContraintEntity>();
	}
	
	public async save(): Promise<ResponseResultSet>
	{
		const repo = RepositoryManager.getInstance().Task;
		return await repo.addAsync(this);
	}
	
	public async moveToColumnAsync(columnId: number) : Promise<ResponseResultSet>
	{
		const repo = RepositoryManager.getInstance().Task;
		return await repo.moveTask(this, columnId);
	}
}
