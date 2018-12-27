import {EntityBase} from "./EntityBase";
import {ResponseResultSet} from "../repos/ResponseResultSet";
import {ErrorModalComponent} from "../components/modals/ErrorModalComponent";

export class SequentialContraintEntity extends EntityBase
{
	public parentTaskId: number;
	public ownerId: number;
	
	async save(): Promise<ResponseResultSet>
	{
		const json = JSON.stringify(this);
		
		console.log(json);
		
		const resultJson = await $.post(
			{
				url: 'http://localhost:8765/api/task/constraint',
				method: 'POST',
				data: json,
				dataType: "json",
				contentType: "application/json; charset=utf-8",
				async: false,
				error: () =>
				{
					ErrorModalComponent.getInstance().showWithMessage('Failed to set parent task :(');
				}
			}
		).responseText;
		
		return JSON.parse(resultJson) as ResponseResultSet;
	}
}