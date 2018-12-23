import {ComponentBase} from "./ComponentBase";
import {Task} from "./Task";

export class Row extends ComponentBase
{
	private static readonly TitleDomClass: string = 'board-title';
	private static readonly TaskContainerDomClass: string = 'board-row-content';
	private static readonly TaskDomClass: string = 'task-card';
	
	private readonly _titleDom: JQuery<HTMLElement>;
	
	private readonly _taskContainerDom: JQuery<HTMLElement>;
	
	private _title: string;
	private _tasks: Array<Task>;
	
	constructor(dom: JQuery<HTMLElement>)
	{
		super(dom);
		this._titleDom = this.childFirstOrDefault(Row.TitleDomClass);
		this._taskContainerDom = this.childFirstOrDefault(Row.TaskContainerDomClass);
		
		this.initialize();
	}
	
	private initialize(): void
	{
		this._tasks = new Array<Task>();
		this._title = this._titleDom.text().trim();
		
		const taskDoms = this.childrenFrom(Row.TaskDomClass, this._taskContainerDom);
		
		taskDoms.forEach((taskDom: JQuery<HTMLElement>) =>
		{
			this._tasks.push(new Task($(taskDom)));
		});
		
		this._tasks.forEach((task: Task) =>
		{
			task.title = "TASK TITLE";
			task.code = "3222";
			task.description = "TOP KEK DESCRE";
		});
	}
	
	public get title()
	{
		return this._title;
	}
	
	public set title(title: string)
	{
		this._title = title;
		this._titleDom.text(title);
	}
}