import {LayoutComponentBase} from "./base/LayoutComponentBase";
import {TaskContainerComponent} from "./TaskContainerComponent";
import {ColumnContainerComponent} from "./ColumnContainerComponent";
import {TaskComponent} from "./TaskComponent";

export class ColumnComponent extends LayoutComponentBase
{
	private readonly _taskContainer: TaskContainerComponent;
	
	constructor(id: string)
	{
		const layout = ColumnComponent.LayoutStorage.ColumnLayout;
		console.log(layout);
		super(id, layout);
		
		const tasksContainerDom = this.JDom.find('.column-tasks-container').get(0);
		this._taskContainer = new ColumnContainerComponent('container', tasksContainerDom, this);
	}
	
	public addTaskComponent(c: TaskComponent) : void
	{
		this._taskContainer.addChild(c);
	}
	
	public removeTaskComponent(c: TaskComponent) : void
	{
		this._taskContainer.removeChild(c);
	}
	
	public set Name(value: string)
	{
		this.JDom.find('.column-name').text(value);
	}
}