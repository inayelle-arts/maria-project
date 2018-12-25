import {LayoutComponentBase} from "./base/LayoutComponentBase";

export class TaskComponent extends LayoutComponentBase
{
	constructor(id: string)
	{
		const layout = TaskComponent.LayoutStorage.TaskLayout;
		super(id, layout);
	}
	
	public set Name(value: string)
	{
		this.JDom.find('.task-name').text(value);
	}
}