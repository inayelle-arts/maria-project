import {ComponentBase} from "./ComponentBase";
import {JFactory} from "./JFactory";

export class BoardComponent extends ComponentBase
{
	public constructor()
	{
		const id = "board";
		
		super(JFactory.singleById(id));
	}
}