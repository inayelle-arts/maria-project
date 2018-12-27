import {CompositeComponentBase} from "../base/CompositeComponentBase";

export class ErrorModalComponent extends CompositeComponentBase
{
	private static readonly __instance__ = new ErrorModalComponent('error-modal');
	
	private constructor(id: string)
	{
		super(id);
	}
	
	public static getInstance(): ErrorModalComponent
	{
		return this.__instance__;
	}
	
	public showWithMessage(message: string, submessage: string = ''): void
	{
		this.jFindByClass('error-modal-content').text(message);
		this.jFindByClass('error-modal-subcontent').text(submessage);
		
		// @ts-ignore
		this.JDom.fadeIn();
		
		setTimeout(() =>
		{
			this.JDom.fadeOut();
		}, 5000);
	}
}