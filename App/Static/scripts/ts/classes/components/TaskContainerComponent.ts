import {ChildComponentBase} from "./base/ChildComponentBase";
import {CompositeComponentBase} from "./base/CompositeComponentBase";

export class TaskContainerComponent extends ChildComponentBase
{
	constructor(id: string, html: HTMLElement, parent: CompositeComponentBase)
	{
		super(id, html, parent);
	}
}