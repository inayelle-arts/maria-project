import {LayoutComponentBase} from "./base/LayoutComponentBase";
import {JEventType} from "../enums/JEventType";
import {JAttribute} from "../enums/JAttribute";

export class TaskComponent extends LayoutComponentBase
{
	private _taskContentOpened: boolean;
	
	constructor(id: string)
	{
		const layout = TaskComponent.LayoutStorage.TaskLayout;
		super(id, layout);
		
		this.initialize();
	}
	
	public initialize(): void
	{
		this._taskContentOpened = false;
		
		const jTaskHeader = this.jFindByClass('task-header');
		
		jTaskHeader.bind(JEventType.Click, () =>
		{
			this.onTaskHeaderClick(jTaskHeader);
		});
	}
	
	public set Name(value: string)
	{
		this.jFindByClass('task-name').text(value);
	}
	
	public set Description(value: string)
	{
		this.jFindByClass('task-description').text(value);
	}
	
	public set Code(value: string)
	{
		this.jFindByClass('task-code').text('#' + value);
	}
	
	private onTaskHeaderClick(sender: JQuery<HTMLElement>): void
	{
		const jTaskBody = this.jFindByClass('task-body');
		
		if (this._taskContentOpened)
		{
			jTaskBody.slideUp('quick');
		} else
		{
			jTaskBody.slideDown('quick');
		}
		
		this._taskContentOpened = !this._taskContentOpened;
	}
}