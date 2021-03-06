import {ColumnContainerComponent} from "./ColumnContainerComponent";
import {ColumnComponent} from "./ColumnComponent";
import {LayoutComponentBase} from "./base/LayoutComponentBase";

export class BoardComponent extends LayoutComponentBase
{
	private readonly _columnContainer: ColumnContainerComponent;
	
	constructor(id: string)
	{
		const layout = BoardComponent.LayoutStorage.BoardLayout;
		super(id.toString(), layout);
		
		const columnContainerDom = this.JDom.find('.board-columns-container').get(0);
		this._columnContainer = new ColumnContainerComponent('container', columnContainerDom, this);
	}
	
	public addColumnComponent(component: ColumnComponent): void
	{
		this._columnContainer.addChild(component);
	}
	
	public removeColumnComponent(component: ColumnComponent): void
	{
		this._columnContainer.removeChild(component);
	}
	
	public set BoardName(value: string)
	{
		this.JDom.find('.board-name').text(value);
	}
	
	public set ProjectName(value: string)
	{
		$("#project-name").text(value);
	}
}