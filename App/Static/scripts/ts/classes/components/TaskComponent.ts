import {LayoutComponentBase} from "./base/LayoutComponentBase";

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
		
		this.JDom.find('.task-header').bind('click', () =>
		{
			this.onTaskHeaderClick();
		});
	}
	
	public set Name(value: string)
	{
		this.JDom.find('.task-name').text(value);
	}
	
	public set Description(value: string)
	{
		this.JDom.find('.task-description').text(value);
	}
	
	public set Code(value: string)
	{
		this.JDom.find('.task-code').text('#' + value);
	}
	
	private onTaskHeaderClick(): void
	{
		const jTaskBody = this.JDom.find('.task-body');
		
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