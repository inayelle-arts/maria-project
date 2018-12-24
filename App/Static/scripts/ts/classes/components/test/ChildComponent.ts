import {ChildComponentBase} from "../base/ChildComponentBase";

export class ChildComponent extends ChildComponentBase
{
	constructor(id: string)
	{
		const layout = "<div class='child'>child content</div>";
		super(id, layout);
	}
}