import {TaskEntity} from "../entities/TaskEntity";
import {RepositoryBase} from "./RepositoryBase";
import {ResponseResultSet} from "./ResponseResultSet";

export class TaskRepository extends RepositoryBase<TaskEntity>
{
	private static readonly URL = 'http://localhost:8765/api/task';
	
	async addAsync(entity: TaskEntity): Promise<ResponseResultSet>
	{
		const entityJson = JSON.stringify(entity);
		
		console.log('ENTJSON: ' + entityJson);
		
		const json = await $.post({
			url: TaskRepository.URL,
			method: 'POST',
			data: entityJson,
			dataType: "json",
			contentType: "application/json; charset=utf-8",
			async: false
		}).responseText;
		
		console.log(json);
		
		const response = JSON.parse(json) as ResponseResultSet;
		entity.id = response.data['id'];
		entity.code = response.data['code'];
		return response;
	}
	
	delete(entity: TaskEntity): boolean
	{
		return false;
	}
	
	get(id: number): TaskEntity
	{
		return undefined;
	}
	
	getAll(): TaskEntity[]
	{
		return [];
	}
	
	async update(entity: TaskEntity): Promise<ResponseResultSet>
	{
		return null;
	}
	
	async moveTask(e: TaskEntity, columnId: number): Promise<ResponseResultSet>
	{
		const body =
			{
				TaskId: e.id,
				TargetColumnId: columnId,
				UserId: 1
			};
		
		const json = JSON.stringify(body);
		
		const jsonResponse = await $.post({
			url: TaskRepository.URL,
			method: 'POST',
			data: json,
			dataType: "json",
			contentType: "application/json; charset=utf-8",
			async: false
		}).responseText;
		
		return JSON.parse(jsonResponse) as ResponseResultSet;
	}
}