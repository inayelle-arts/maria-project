import {ChildComponentBase} from "../base/ChildComponentBase";

export class ChildComponent extends ChildComponentBase
{
	constructor(id: string)
	{
		const layout =
			`<p class='child'>
				child content
			 </p>`;
		super(id, layout);
	}
}