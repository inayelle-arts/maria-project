import {CompositeComponentBase} from "../base/CompositeComponentBase";

export class LoadingModalComponent extends CompositeComponentBase
{
	private _isVisible: boolean;
	
	constructor(id: string)
	{
		super(id);
		this._isVisible = false;
	}
}