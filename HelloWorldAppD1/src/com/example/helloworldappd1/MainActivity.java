package com.example.helloworldappd1;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

/**
 * @author zhujinrong
 * 
 */
public class MainActivity extends Activity {
	/**
	 * ±à¼­¿ò
	 */
	private EditText getNameEditText;

	/**
	 * µÇÂ½°´Å¥
	 */
	private Button loginButton;

	/**
	 * Õ¹Ê¾µÇÂ½ÐÅÏ¢µÄTextView
	 */
	private TextView showLoginTextView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.setContentView(R.layout.activity_main);

		try {
			this.getNameEditText = (EditText) this
					.findViewById(R.id.widget50_getName_EditText);
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		
		this.loginButton = (Button) this
				.findViewById(R.id.widget30_login_button);
		this.showLoginTextView = (TextView) this
				.findViewById(R.id.widget31_showLogin_textView);
		loginButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {
				// TODO Auto-generated method stub
				showLoginTextView.setText(getNameEditText.getText() + ",»¶Ó­ÄúµÇÂ½£¡");
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}
