import {LayoutRepository} from "../../repos/LayoutRepository";
import {ChildComponentBase} from "./ChildComponentBase";

export abstract class LayoutComponentBase extends ChildComponentBase
{
	protected static readonly LayoutStorage: LayoutRepository = new LayoutRepository();
	
	private readonly _layout: string;
	
	protected constructor(id: string, layout: string)
	{
		const tag = $(layout).prop('tagName');
		const html = document.createElement(tag) as HTMLElement;
		html.id = id;
		html.className = ($(layout).prop('className'));
		html.innerHTML = $(layout).prop('innerHTML');
		
		super(id, html);
		this._layout = layout;
	}
}